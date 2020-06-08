const express = require("express");
const router = express.Router();
const axios = require("axios");



// Home Page ----------------------------------------------------

router.get("/", async (req, res) => {

    await axios.get("http://localhost:5000/api/Vaga").then((response) => {

      res.render("admin/index.handlebars", { response: response });

    }).catch((err) => {
        
      console.group("Error === " + err);

    });
});


// Nova Vaga -----------------------------------------------------

router.get("/nova-vaga", (req, res) => {

  res.render("admin/vagaAdd.handlebars");

});


// Post Nova Vaga ------------------------------------------------

router.post("/nova-vaga/add", async (req, res) => {

  let erros = [];

  if(!req.body.titulo || typeof req.body.titulo == undefined || req.body.titulo == null){
      erros.push(1);
  }

  if(!req.body.empresa || typeof req.body.empresa == undefined || req.body.empresa == null){
    erros.push(1);
  }

  if(!req.body.cidade || typeof req.body.cidade == undefined || req.body.cidade == null){
    erros.push(1);
  }    
      
  if(!req.body.email || typeof req.body.email == undefined || req.body.email == null){
    erros.push(1);
  }

  if(!req.body.telefone || typeof req.body.telefone == undefined || req.body.telefone == null){
    erros.push(1);
  }

  if(!req.body.informacoes || typeof req.body.informacoes == undefined || req.body.informacoes == null){
    erros.push(1);
  }

  if(erros.length > 0){
       
      res.render('admin/vagaAdd.handlebars');

  }else{

    await axios.post("http://localhost:5000/api/Vaga/", {

      company: req.body.empresa,
      title:req.body.titulo,
      email:req.body.email,
      phone:req.body.telefone,
      InformationVacancy:req.body.informacoes,
      city:req.body.cidade

    }).then((response) => {

      res.redirect('http://localhost:8080/');

    }).catch((err) => {

      console.group("Error === " + err);

    });

  }

});

// Editar Rota ---------------------------------------------------------

router.get("/editar-vaga/:slug", async (req, res) => {

  let slug = req.params.slug;
  
  await axios.get("http://localhost:5000/api/Vaga/"+slug).then((response) => {
    
    res.render("admin/vagaEdit.handlebars", { response: response });

  }).catch((err) => {
    console.group("Error === " + err);

  });

});

// Editar Rota ---------------------------------------------------------

router.post("/editar-vaga/edit", async (req, res) => {

  
  let erros = [];

  if(!req.body.titulo || typeof req.body.titulo == undefined || req.body.titulo == null){
      erros.push(1);
  }

  if(!req.body.empresa || typeof req.body.empresa == undefined || req.body.empresa == null){
    erros.push(1);
  }

  if(!req.body.cidade || typeof req.body.cidade == undefined || req.body.cidade == null){
    erros.push(1);
  }    
      
  if(!req.body.email || typeof req.body.email == undefined || req.body.email == null){
    erros.push(1);
  }

  if(!req.body.telefone || typeof req.body.telefone == undefined || req.body.telefone == null){
    erros.push(1);
  }

  if(!req.body.informacoes || typeof req.body.informacoes == undefined || req.body.informacoes == null){
    erros.push(1);
  }

  if(erros.length > 0){
      res.render('admin/editVagas.handlebars');

  }else{

    //let slug = req.params.slug;

    await axios.put("http://localhost:5000/api/Vaga/"+req.body.id, {
      company: req.body.empresa,
      title:req.body.titulo,
      email:req.body.email,
      phone:req.body.telefone,
      InformationVacancy:req.body.informacoes,
      city:req.body.cidade

    }).then((response) => {

      res.redirect('http://localhost:8080/admin');

    }).catch((err) => {
      console.group("Error === " + err);

    });

  }

});

// Apagar vaga ---------------------------------------------------------

router.get("/editar-vaga/delete/:id", async (req, res) => {

  await axios.delete("http://localhost:5000/api/Vaga/"+req.params.id).then((response) => {

    res.redirect('http://localhost:8080/admin');

  }).catch((err) => {
      
    console.group("Error === " + err);

  });

});

module.exports = router;