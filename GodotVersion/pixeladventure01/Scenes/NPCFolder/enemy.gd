extends CharacterBody2D

@onready var animator: AnimatedSprite2D = $animator
@onready var ray_cast_2d: RayCast2D = $animator/RayCast2D


var gravity = 500
var max_fall_speed = 500
var direction = 1
var move_speed = 50

func _ready() -> void:
	pass

func _physics_process(delta: float) -> void:
	apply_gravity(delta)
	move_enemy()
	move_and_slide()
	
func apply_gravity(delta):
	if not is_on_floor():
		velocity.y = move_toward(velocity.y, max_fall_speed, gravity * delta)
 
func move_enemy():
	if is_on_wall() or not ray_cast_2d.is_colliding():
		direction = -direction
	velocity.x = direction * move_speed
	if velocity.x < 0:
		animator.flip_h = true
		ray_cast_2d.position.x = -11
	else:
		animator.flip_h = false
		ray_cast_2d.position.x = 11


func _on_hitbox_body_entered(body: Node2D) -> void:
	body.velocity.y = -200
	animator.play("die")
	await animator.animation_finished
	queue_free()
