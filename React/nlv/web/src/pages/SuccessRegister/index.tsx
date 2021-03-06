import React from "react";
import { Link } from "react-router-dom";

import imgBackgroud from "../../assets/images/background_sucess.svg";
import feitoIcon from "../../assets/images/icons/feito.svg";

import "./styles.css";

function SucessRegister() {
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
          <h1>Cadastro Concluido!</h1>
          <span>Agora você faz parte da plataforma da Proffy.</span>
          <span>Tenha uma ótima experiência.</span>
          <Link to="/">Fazer Login</Link>
        </div>
      </div>
    </div>
  );
}

export default SucessRegister;
