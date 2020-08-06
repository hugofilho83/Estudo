import express from "express";

const app = express();

app.use(express.json());

//Verbos HTTP
//GET: Buscar ou listar uma informacao
//POST: Criar aluma nova informacao
//PUT: Atualizar uma informacao existente
//DELETE: Delete uma informacao existente

//==============================

//Tipos de Parametros
//Corpo (Request Body): Dados para criação ou atulização de um registro
//Route Params: Identificar qual recurso que será ataulizado ou deletado exe app.post("/users:id",(request, response)) o parametro e o :id
//Query Params: São os parametros passado na url ex: http://localhost:3333/users?page=2&sort=name os parametros(?page=2&sort=name) são usados para filtros, paginacao e ordenacao

app.post("/users", (request, response) => {
  return response.send({ messeger: "hello word" });
});

app.listen(3333);
