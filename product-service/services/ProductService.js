const Product=require("../models/ProductModel")

const add=(data)=>{
    const product=new Product(data)
    return product.save()
}

const getAll=()=>{
    return Product.find({})
}

const getById=(id)=>{
    return Product.findById(id)
}
module.exports={
    add,
    getAll,
    getById
}