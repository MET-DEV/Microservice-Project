package handlers

import (
	"encoding/json"
	"net/http"

	"github.com/MET-DEV/customer-service/migrations"
	"github.com/MET-DEV/customer-service/models"
	"github.com/gorilla/mux"
)

func Add(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	var customer models.Customer
	json.NewDecoder(r.Body).Decode(&customer)
	migrations.DB.Create(&customer)
	json.NewEncoder(w).Encode(customer)
}
func GetAll(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	var customers []models.Customer
	migrations.DB.Find(&customers)
	json.NewEncoder(w).Encode(&customers)
}
func GetById(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	params := mux.Vars(r)
	var customer models.Customer
	migrations.DB.First(&customer, params["id"])
	json.NewEncoder(w).Encode(customer)
}
