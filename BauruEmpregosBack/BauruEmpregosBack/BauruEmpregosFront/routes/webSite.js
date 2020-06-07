const express = require("express");
const router = express.Router();
const axios = require("axios");


router.get("/", async (req, res) => {

  await axios.get("http://localhost:5000/api/Vaga").then((response) => {
      
      res.render("webSite/index.handlebars", { response: response });

    }).catch((err) => {
      console.group("Error === " + err);

    });
});


router.get("/posts/:slug", async (req, res) => {

  let slug = req.params.slug;

  console.log("http://localhost:5000/api/Vaga/"+slug);
  
  await axios.get("http://localhost:5000/api/Vaga/"+slug).then((response) => {
    console.group(response.data);
    res.render("posts/index.handlebars", { response: response });

  }).catch((err) => {
    console.group("Error === " + err);

  });

});


module.exports = router;
