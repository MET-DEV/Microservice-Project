package models

import (
	"gorm.io/gorm"
)

type Customer struct {
	gorm.Model
	FirstName         string `json:"firstname"`
	LastName          string `json:"lastname"`
	Email             string `json:"email"`
	PhoneNumber       string `json:"phone"`
	NationalityNumber string `json:"national_id"`
}
