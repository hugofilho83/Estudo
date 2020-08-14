import React from "react";
import { Link } from "react-router-dom";

import imgBackgroud from "../../assets/images/background_sucess.svg";
import feitoIcon from "../../assets/images/icons/feito.svg";

import "./styles.css";

function SucessNew() {
  return (
    <div id="page-success">
      <div id="page-success-content" className="container">
        <div
          className="imgBackground"
          style={{
            backgroundImage: "url(" + imgBackgroud + ")",
            backgroundPosition: "center",
            backgroundSize: "contain",
            backgroundRepeat: "no-repeat",
            margin: 10,
          }}
        ></div>

        <div className="messager">
          <img src={feitoIcon} alt="feito" />
          <h1>Cadastro salvo!</h1>
          <span>
            Tudo certo, seu cadastro está na nossa lista de professores.
          </span>
          <span>Agora é só ficar de olho no seu WhatsApp.</span>
          <Link to="/">Acessar</Link>
        </div>
      </div>
    </div>
  );
}

export default SucessNew;
