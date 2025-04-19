extends CharacterBody2D

#Export Variables
@export var move_speed : float = 100.0
@export var gravity : float = 500.0
@export var jump_force : float = 200.0
#Onready Variables
@onready var animated_sprite_2d: AnimatedSprite2D = $AnimatedSprite2D

#Other Variables
var can_double_jump : bool = true
var max_fall_speed : float = 500.0
var has_control = false

func _ready():
	animated_sprite_2d.play("appear")
	await animated_sprite_2d.animation_finished
	has_control = true

func _physics_process(delta: float) -> void:
	if has_control:
		apply_gravity(delta)
		jump()
		move_player()
		animate()
		move_and_slide()
	
func move_player():
	var move_axis = Input.get_axis("move_left", "move_right")
	velocity.x = move_axis * move_speed
	
func apply_gravity(delta):
	if not is_on_floor():
		velocity.y = move_toward(velocity.y, max_fall_speed, gravity * delta)
		

func jump():
	
	var jump_pressed = Input.is_action_just_pressed("jump")
	
	if is_on_floor():
		if jump_pressed:
			velocity.y = -jump_force
	if not is_on_floor() and can_double_jump and jump_pressed:
		velocity.y = -jump_force
		can_double_jump = false
	
	reset_double_jump()



func animate():
	if is_on_floor():
		if velocity.x != 0:
			animated_sprite_2d.play("run")
		else:
			animated_sprite_2d.play("idle")
			
	#When I Jump
	if not is_on_floor():
		if velocity.y <= 0:
			animated_sprite_2d.play("jump")
		if velocity.y > 0:
			animated_sprite_2d.play("fall")
	
	if velocity.x < 0:
		animated_sprite_2d.flip_h = true
	if velocity.x > 0:
		animated_sprite_2d.flip_h = false

		


func reset_double_jump():
	if is_on_floor():
		can_double_jump = true
	
