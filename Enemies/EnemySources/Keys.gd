extends Panel

@onready var textLabel = $Label

@export var text = ""

func _ready() -> void:
	textLabel.text = text
