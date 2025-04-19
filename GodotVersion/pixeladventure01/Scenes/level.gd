extends Node2D

var level_scene = preload("res://Scenes/level.tscn")

@onready var apple_label: Label = $CanvasLayer/Panel/AppleLabel
@onready var audio_stream_player: AudioStreamPlayer = $AudioStreamPlayer
@onready var game_over_panel: Panel = $CanvasLayer/GameOverPanel

var apples_in_level

func _ready():
	update_apple_label()

func _process(_delta):
	update_apple_label()

	
func update_apple_label():
	apple_label.text = str(InstanceTracker.apples_collected)
	
func quit_game():
	get_tree().quit()


func _on_button_pressed() -> void:
	if audio_stream_player.is_playing():
		audio_stream_player.stop()
	else:
		audio_stream_player.play()

func restart_level():
	get_tree().call_deferred("change_scene_to_file", "res://Scenes/level.tscn")
	InstanceTracker.apples_collected = 0
	get_tree().paused = false

func _on_kill_box_body_entered(body: Node2D) -> void:
	get_tree().call_deferred("change_scene_to_file", "res://Scenes/title_screen.tscn")
	InstanceTracker.apples_collected = 0
	

func _on_hurtbox_body_entered(body: Node2D) -> void:
	get_tree().call_deferred("change_scene_to_file", "res://Scenes/title_screen.tscn")
	InstanceTracker.apples_collected = 0


func _on_checkpoint_flag_end_reached() -> void:
	get_tree().paused = true
	game_over_panel.visible = true
