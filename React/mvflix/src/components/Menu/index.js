import React from "react";
import Logo from "../../assets/img/logo_mvflix.png";
import "./Menu.css";
import Button from "../../components/Button";

//import ButtonLink from "./components/ButtonLink";

function Menu() {
  return (
    <nav className="Menu">
      <a href="/">
        <img className="Logo" src={Logo} alt="MVFlix logo" />
      </a>

      <Button as="a" className="ButtonLink" href="/">
        Novo Vídeo
      </Button>
    </nav>
  );
}

export default Menu;
