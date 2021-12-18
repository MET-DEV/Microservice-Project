const express=require("express")
const {getProductById,getAllProducts,create}=require("../controllers/ProductsController")


const router=express.Router()

router.route("/").get(getAllProducts)
router.route("/").post(create)
router.route("/:id").get(getProductById)
module.exports=router;