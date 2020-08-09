import React, { FormEvent, useState } from "react";
import { useHistory } from "react-router-dom";

import InputCustom from "../../components/InputCustom";
import PageHeader from "../../components/PageHeader";
import warningIcon from "../../assets/images/icons/warning.svg";

import "./styles.css";
import TextAreaCustom from "../../components/TextAreaCustom";
import SelectCustom from "../../components/SelectCustom";
import api from "../../services/api";

function TeacherForm() {
  const history = useHistory();

  /*guardando o estado dos componentes do fomulario */
  const [name, setName] = useState("");
  const [avatar, setAvatar] = useState("");
  const [whatsapp, setWhatsapp] = useState("");
  const [bio, setBio] = useState("");
  const [subject, setSubject] = useState("");
  const [cost, setCost] = useState("");
  /*================================================*/

  /*quardando o estado dos item schedule(horário)==================*/
  const [scheduleItems, setScheduleItem] = useState([
    { week_day: 0, from: "", to: "" },
  ]);

  function addNewScheduleItem() {
    setScheduleItem([
      ...scheduleItems,
      {
        week_day: 0,
        from: "",
        to: "",
      },
    ]);
  }
  /*==============================================================*/

  /*atualizando o estado dos itens do horario=========================*/
  function setScheduleItemValue(
    position: number,
    field: string,
    value: string
  ) {
    const updateScheduleItem = scheduleItems.map((item, index) => {
      if (index === position) {
        return { ...item, [field]: value };
      }
      return item;
    });

    console.log(updateScheduleItem);

    setScheduleItem(updateScheduleItem);
  }
  /*===============================================================*/

  /*Evento de ação do fomulario para salvar os dados do formulario*/
  function handleCreateClass(e: FormEvent) {
    e.preventDefault();

    api
      .post("/classes", {
        name,
        avatar,
        whatsapp,
        bio,
        subject,
        cost: Number(cost),
        schedule: scheduleItems,
      })
      .then(() => {
        alert("Cadastro realizado com sucesso.");
        history.push("/");
      })
      .catch(() => {
        alert("Erro ao cadastrar a(s) aula(s).");
      });

    console.log({
      name,
      avatar,
      whatsapp,
      bio,
      subject,
      cost,
      scheduleItems,
    });
  }
  /*==============================================================*/

  return (
    <div id="page-teacher-form" className="container">
      <PageHeader
        title="Que incrivel que você quer dar aulas."
        description="O primeiro passo é preencher esse formulário de inscrição."
      />
      <main>
        <form onSubmit={handleCreateClass}>
          <fieldset>
            <legend>Seus dados</legend>
            <InputCustom
              name="name"
              label="Nome Completo"
              value={name}
              onChange={(e) => {
                setName(e.target.value);
              }}
            />

            <InputCustom
              name="avatar"
              label="Avatar"
              value={avatar}
              onChange={(e) => {
                setAvatar(e.target.value);
              }}
            />

            <InputCustom
              name="whatsapp"
              label="WhastSapp"
              value={whatsapp}
              onChange={(e) => {
                setWhatsapp(e.target.value);
              }}
            />

            <TextAreaCustom
              name="bio"
              label="Biografia"
              value={bio}
              onChange={(e) => {
                setBio(e.target.value);
              }}
            />
          </fieldset>

          <fieldset>
            <legend>Sobre a aula</legend>
            <SelectCustom
              name="subject"
              label="Matéria"
              value={subject}
              onChange={(e) => {
                setSubject(e.target.value);
              }}
              options={[
                { value: "Artes", label: "Artes" },
                { value: "Biologia", label: "Biologia" },
                { value: "Ciências", label: "Ciências" },
                { value: "Educação Física", label: "Artes" },
                { value: "Geografia", label: "Geografia" },
                { value: "História", label: "História" },
                { value: "Matemática", label: "Matemática" },
                { value: "Português", label: "Português" },
                { value: "Química", label: "Química" },
                { value: "Física", label: "Física" },
              ]}
            />

            <InputCustom
              name="cost"
              label="Custo da hora aula"
              value={cost}
              onChange={(e) => {
                setCost(e.target.value);
              }}
            />
          </fieldset>

          <fieldset>
            <legend>
              Horário disponiveis
              <button type="button" onClick={addNewScheduleItem}>
                + Novo Horário
              </button>
            </legend>
            {scheduleItems.map((scheduleItem, index) => {
              return (
                <div key={scheduleItem.week_day} className="schedule-item">
                  <SelectCustom
                    name="week_day"
                    label="Dia da Semana"
                    value={scheduleItem.week_day}
                    onChange={(e) =>
                      setScheduleItemValue(index, "week_day", e.target.value)
                    }
                    options={[
                      { value: "0", label: "Domingo" },
                      { value: "1", label: "Segunda-Feira" },
                      { value: "2", label: "Terça-Feira" },
                      { value: "3", label: "Quarta-Feira" },
                      { value: "4", label: "Quinta-Feira" },
                      { value: "5", label: "Sexta-Feira" },
                      { value: "6", label: "Sabado" },
                    ]}
                  />
                  <InputCustom
                    name="from"
                    label="Das"
                    type="time"
                    value={scheduleItem.from}
                    onChange={(e) =>
                      setScheduleItemValue(index, "from", e.target.value)
                    }
                  />
                  <InputCustom
                    name="to"
                    label="Até"
                    type="time"
                    value={scheduleItem.to}
                    onChange={(e) =>
                      setScheduleItemValue(index, "to", e.target.value)
                    }
                  />
                </div>
              );
            })}
          </fieldset>

          <footer>
            <p>
              <img src={warningIcon} alt="Aviso importante" />
              Importante!
              <br />
              Preencher todos os dados.
            </p>
            <button type="submit">Salvar Cadastro</button>
          </footer>
        </form>
      </main>
    </div>
  );
}

export default TeacherForm;
