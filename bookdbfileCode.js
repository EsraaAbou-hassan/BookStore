db.book.insertOne({_id:1,Name:"esraa", Img:"samir", Price:2

, ISBN:2,Author:"tanta",Year_of_publication:2,Description:"tanta", Publishing:"tanta"})

db.book.find({})

use 



db.createCollection("book",{

    

     validator:{



            $jsonSchema:{



                bsonType:"object", 



            required:["_id","Name", "Img", "Price","ISBN","Author"],



                additionalProperties:false,



                properties:{



                    _id:{bsonType:"number"},



                    Name:{bsonType:"string",maxLength:50,description: "must be a string and is required"},

                    Img:{bsonType:"string",maxLength:100,description: "must be a string and is required"},

                   

                    Price:{bsonType:"number",description: "must be a string and is required"},

                    ISBN:{bsonType:"number",description: "must be a string and is required"},

                    Author:{bsonType:"string",description: "must be a string and is required"},

                    Year_of_publication:{bsonType:"number"},

                    Description:{bsonType:"string"},

                    Publishing:{bsonType:"string"},

                    }//properties



                 }//jsonSchema



        }//validators



    



    });//end create collection



                

