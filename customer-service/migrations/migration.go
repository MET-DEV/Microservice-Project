package migrations

import (
	"fmt"

	"github.com/MET-DEV/customer-service/models"
	"gorm.io/driver/postgres"
	"gorm.io/gorm"
)

var DB *gorm.DB
var err error

const dbstring = "host=localhost user=postgres password=12345 dbname=CustomerDb port=5432 sslmode=disable"

func InitialMigration() {
	DB, err = gorm.Open(postgres.Open(dbstring), &gorm.Config{})
	if err != nil {
		fmt.Println(err.Error())
	}
	DB.AutoMigrate(&models.Customer{})
}
