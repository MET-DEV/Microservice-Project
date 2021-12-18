const {add,getAll,getById}=require("../services/ProductService")
const httpStatus=require("http-status")

const create=(req,res)=>{
    add(req.body).then(response=>{
        res.status(httpStatus.OK).send(response)
    }).catch(e=>res.status(httpStatus.INTERNAL_SERVER_ERROR).send({error:e}))
}
const getAllProducts=(req,res)=>{
    getAll().then(response=>{
        res.status(httpStatus.OK).send(response)
    }).catch(e=>res.status(httpStatus.INTERNAL_SERVER_ERROR).send(e))
}
const getProductById=(req,res)=>{
    if(!req.params?.id) return res.status(httpStatus.BAD_REQUEST).send({message:"Id is required"})
    getById(req.params.id).then(data=>res.status(httpStatus.OK).send(data)).catch(e=>res.status(httpStatus.INTERNAL_SERVER_ERROR).send(e))
}

module.exports={
    create,
    getAllProducts,
    getProductById
}