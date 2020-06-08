const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');
const webSite = require('./routes/webSite');
const Admin = require('./routes/Admin');
const path = require('path');
const app = express();



//Bodyparser
    app.use(bodyParser.urlencoded({extended:true}));
    app.use(bodyParser.json());

//Handlebars
    app.engine('handlebars',handlebars({defaultLayout:'main'}));
    app.set('view engeni','handlebars');

//Public
    app.use(express.static(__dirname + '/public'));
    app.use('/js', express.static(path.join(__dirname + '/node_modules/jquery/dist/'))); // redirect JS jQuery
    app.use('/js', express.static(path.join(__dirname + '/node_modules/popper.js/dist/umd/'))); // redirect JS jQuery        
    app.use('/js', express.static(path.join(__dirname + '/node_modules/bootstrap/dist/js'))); // redirect bootstrap JS
    app.use('/css', express.static(path.join(__dirname + '/node_modules/bootstrap/dist/css'))); // redirect CSS bootstrap

//rotas
    app.use('/',webSite);
    app.use('/admin',Admin);

//porta
    const port = 8080;

//escutando a porta
    app.listen(port,() => {
        console.log("Conectado...");
        console.log("http://localhost:"+port);
    });