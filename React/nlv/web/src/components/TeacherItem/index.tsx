import React from "react";
import whatsappIcon from "../../assets/images/icons/whatsapp.svg";

import "./styles.css";

function TeacherItem() {
  return (
    <article className="teacher-item">
      <header>
        <img
          src="https://scontent.frec28-1.fna.fbcdn.net/v/t1.0-1/p200x200/21687523_1673028642731608_5110942743974756868_n.jpg?_nc_cat=105&_nc_sid=7206a8&_nc_ohc=_RRYwbe_8cUAX-oN_fw&_nc_oc=AQn1-uHVPysKutoj9zXeQimFIDUMkY5M6mvy882elHQWj-BvCtFg1HiTGLSoNqfD2YM&_nc_ht=scontent.frec28-1.fna&_nc_tp=6&oh=f739d834751d1f9501451958e0119e0a&oe=5F504F6F"
          alt="Hugo Tavares"
        />
        <div>
          <strong>Hugo Tavares</strong>
          <span>Química</span>
        </div>
      </header>
      <p>
        What is Lorem Ipsum?
        <br />
        <br />
        Lorem Ipsum is simply dummy text of the printing and typesetting
        industry. Lorem Ipsum has been the industry's standard dummy text ever
        since the 1500s, when an unknown printer took a galley of type and
        scrambled it to make a type specimen book. It has survived not only five
        centuries, but also the leap into electronic typesetting, remaining
        essentially unchanged. It was popularised in the 1960s with the release
        of Letraset sheets containing Lorem Ipsum passages, and more recently
        with desktop publishing software like Aldus PageMaker including versions
        of Lorem Ipsum.
      </p>

      <footer>
        <p>
          Preço/hora
          <strong>R$ 80,00</strong>
        </p>
        <button type="button">
          <img src={whatsappIcon} alt="whatsapp" />
          Entrar em contato
        </button>
      </footer>
    </article>
  );
}

export default TeacherItem;
