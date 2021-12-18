const Mongoose=require("mongoose")



const ProductSchema=new Mongoose.Schema({
    product_name:String,
    stock_amount:Number,
    description:String,
    category:String,
    unit_price:Number,

    
    
},{timestamps:true,versionKey:false})

module.exports=Mongoose.model("products",ProductSchema)