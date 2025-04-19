extends StaticBody2D


func _on_hurtbox_body_entered(body: Node2D) -> void:
	if body.is_in_group("player"):
		pass#body.queue_free()
