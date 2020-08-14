import React from "react";
import { Link } from "react-router-dom";

import imgBackgroud from "../../assets/images/background_sucess.svg";
import feitoIcon from "../../assets/images/icons/feito.svg";

import "./styles.css";

function SucessReset() {
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
          <h1>Redefinição enviada!</h1>
          <span>Boa, agora é só checar o e-mail que foi enviado para</span>
          <span>você redefinir sua senha e aproveitar os estudos.</span>
          <Link to="/">Voltar Login</Link>
        </div>
      </div>
    </div>
  );
}

export default SucessReset;
