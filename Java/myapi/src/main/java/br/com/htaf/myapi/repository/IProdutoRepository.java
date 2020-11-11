package br.com.htaf.myapi.repository;

import br.com.htaf.myapi.models.Produto;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IProdutoRepository extends JpaRepository<Produto, Long> {

}
