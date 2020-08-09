import React, { useState } from "react";
import { ScrollView, Text, TextInput, View } from "react-native";
import { BorderlessButton, RectButton } from "react-native-gesture-handler";
import PageHeader from "../../componets/PageHeader";
import TeacherItem, { Teacher } from "../../componets/TeacherItem";
import { Feather } from "@expo/vector-icons";
import AsyncStorege from "@react-native-community/async-storage";
import { useFocusEffect } from "@react-navigation/native";

import styles from "./styles";
import api from "../../services/api";

function TeacherList() {
  /*guarda o estado da lista de professores */
  const [teachers, setTeachers] = useState([]);
  /*guarda o estado da lista de professores favoritados */
  const [favorites, setFavorites] = useState<number[]>([]);
  /*guarda o estado da se a lista de filtragem esta visivel*/
  const [isFilterVible, setIsFilterVible] = useState(false);

  /*guarda o estado dos campos da lista de filtragem */
  const [week_day, setWeekDay] = useState("");
  const [subject, setSugject] = useState("");
  const [time, setTime] = useState("");
  /*================================================ */

  function loadFavorites() {
    AsyncStorege.getItem("favorites").then((response) => {
      if (response) {
        const favoritedTeachers = JSON.parse(response);
        const favoritedTeachersId = favoritedTeachers.map(
          (teacher: Teacher) => {
            return teacher.id;
          }
        );

        setFavorites(favoritedTeachersId);
      }
    });
  }

  useFocusEffect(() => {
    loadFavorites();
  });

  /*click button filter show params filter */
  function handleToggleFiltersVisible() {
    setIsFilterVible(!isFilterVible);
  }

  /*click button filter */
  async function handleFilterSubmit() {
    loadFavorites();
    const response = await api.get("/classes", {
      params: { subject, week_day, time },
    });
    setTeachers(response.data);
    setIsFilterVible(false);
  }

  /*retorna a view que sera exibida em tela */
  return (
    <View style={styles.container}>
      <PageHeader
        title="Proffys disponíveis"
        headerRight={
          <BorderlessButton
            onPress={handleToggleFiltersVisible}
            style={styles.buttonFilter}
          >
            <Feather name="filter" size={25} color="#fff" />
          </BorderlessButton>
        }
      >
        {
          /*verifiaca se a lista pode ser exibida ou não */
          isFilterVible && (
            <View style={styles.searchForm}>
              <Text style={styles.label}>Matérial</Text>
              <TextInput
                style={styles.input}
                value={subject}
                onChangeText={(text) => setSugject(text)}
                placeholder="Qual a matéria?"
                placeholderTextColor="#c1bccc"
              />

              <View style={styles.inputGroup}>
                <View style={styles.inputBlock}>
                  <Text style={styles.label}>Dia da Semana</Text>
                  <TextInput
                    style={styles.input}
                    value={week_day}
                    onChangeText={(text) => setWeekDay(text)}
                    placeholder="Qual o dia?"
                    placeholderTextColor="#c1bccc"
                  />
                </View>

                <View style={styles.inputBlock}>
                  <Text style={styles.label}>Horário</Text>
                  <TextInput
                    style={styles.input}
                    value={time}
                    onChangeText={(text) => setTime(text)}
                    placeholder="Qual o Horário?"
                    placeholderTextColor="#c1bccc"
                  />
                </View>
              </View>
              <RectButton
                onPress={handleFilterSubmit}
                style={styles.submitButton}
              >
                <Text style={styles.submitButtonText}>Filtrar</Text>
              </RectButton>
            </View>
          )
        }
      </PageHeader>

      <ScrollView
        style={styles.teacherList}
        contentContainerStyle={{
          paddingHorizontal: 16,
          paddingBottom: 16,
        }}
      >
        {teachers.map((teacher: Teacher) => {
          return (
            <TeacherItem
              key={teacher.id}
              teacher={teacher}
              favorited={favorites.includes(teacher.id)}
            />
          );
        })}
      </ScrollView>
    </View>
  );
}

export default TeacherList;
