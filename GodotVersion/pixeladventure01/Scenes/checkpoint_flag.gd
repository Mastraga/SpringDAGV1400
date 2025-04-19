extends AnimatedSprite2D

@export var flag_down : bool = true

signal end_reached

func _on_area_2d_body_entered(body: Node2D) -> void:
	if body.is_in_group("player"):
		if flag_down:
			play("flag_out")
			await(animation_finished)
			end_reached.emit()
			play("flag_idle")
			flag_down = false
	
