const express=require('express');
const config=require("./config");
const loaders=require("./loaders")
const ProductRoute=require("./routes/ProductRoute")


config();
loaders();

const app=express();

app.use(express.json())

app.listen(process.env.APP_PORT,()=>{
    console.log("Server running")
    app.use("/api/products",ProductRoute)
    
})