package br.com.htaf.myapi.controller;

import br.com.htaf.myapi.models.Produto;
import br.com.htaf.myapi.repository.IProdutoRepository;
import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api")
@Api(value = "API Res Produtos")
@CrossOrigin(origins = "*")
public class ProdutoController {

    @Autowired
    IProdutoRepository produtoRepository;

    @GetMapping("/produtos")
    @ApiOperation(value = "Retorna uma lista de produtos")
    public List<Produto> listarProdutos(){
        return produtoRepository.findAll();
    }

    @GetMapping("/produtos/{id}")
    @ApiOperation(value = "Retorna uma api deacordo com o ID passado")
    public Object listarProdutoById(@PathVariable(value = "id") long id){
        var produto = produtoRepository.findById(id);

        if(produto.isEmpty()) {
            return new ResponseEntity<Void>(HttpStatus.BAD_REQUEST);
        }

        return produto;


    }

    @PostMapping("/produtos")
    @ApiOperation(value = "Salva um produto")
    public Object InserirProduto(@RequestBody Produto produto){
        produtoRepository.save(produto);
        return new ResponseEntity<Void>(HttpStatus.CREATED);
    }

    @DeleteMapping("/produtos")
    @ApiOperation(value = "Remove um produto")
    public Object DeletarProduto(@RequestBody Produto produto){
        produtoRepository.delete(produto);
        return new ResponseEntity<Void>(HttpStatus.OK);
    }

    @PutMapping("/produtos")
    @ApiOperation(value = "Atualiza um produto")
    public Object AtualizarProduto(@RequestBody Produto produto){
        return produtoRepository.save(produto);
    }
}
