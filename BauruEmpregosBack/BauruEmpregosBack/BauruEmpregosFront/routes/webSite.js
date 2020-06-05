const express = require('express');
const router = express.Router();
const axios = require('axios');


router.get('/',async (req,res) => {
    await axios.get('http://localhost:5000/api/Vaga').then((response) => {
        console.group(response.data);
    }).catch((err) => {
        console.group("Error === "+err);
    })
    res.render('webSite/index.handlebars');
});

module.exports = router;