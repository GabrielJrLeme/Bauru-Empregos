const express = require("express");
const router = express.Router();
const axios = require("axios");



// Home Page
router.get("/", async (req, res) => {

  await axios.get("http://localhost:5000/api/Vaga").then((response) => {
      res.render("webSite/index.handlebars", { response: response });

    }).catch((err) => {
      console.group("Error === " + err);

    });
});



// Page Vaga
router.get("/vaga/:slug", async (req, res) => {

  let slug = req.params.slug;
  
  await axios.get("http://localhost:5000/api/Vaga/"+slug).then((response) => {
    
    res.render("vaga/index.handlebars", { response: response });

  }).catch((err) => {
    console.group("Error === " + err);

  });

});

router.get("/error", async (req, res) => {

  res.render("error/notFound.handlebars");

});


module.exports = router;
