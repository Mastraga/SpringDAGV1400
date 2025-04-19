extends AnimatedSprite2D

@onready var apple: AnimatedSprite2D = $"."

func _on_area_2d_body_entered(body: Node2D) -> void:
	if body.is_in_group("player"):
		InstanceTracker.apples_collected += 1
		apple.play("collect")
		await(apple.animation_finished)
		queue_free()
