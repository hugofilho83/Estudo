import React from "react";

import { BrowserRouter, Route } from "react-router-dom";
import Landing from "./pages/Landing";
import Login from "./pages/Login";
import Register from "./pages/Register";
import ResetPassword from "./pages/ResetPassword";
import SucessNew from "./pages/SuccessNew";
import SucessRegister from "./pages/SuccessRegister";
import SucessReset from "./pages/SuccessReset";
import TeacherForm from "./pages/TeacherForm";
import TeacherList from "./pages/TeacherList";

function Routes() {
  return (
    <BrowserRouter>
      <Route path="/" exact component={Login} />
      <Route path="/landing" exact component={Landing} />
      <Route path="/study" exact component={TeacherList} />
      <Route path="/give-classes" exact component={TeacherForm} />
      <Route path="/register" exact component={Register} />
      <Route path="/success-register" exact component={SucessRegister} />
      <Route path="/success-new" exact component={SucessNew} />
      <Route path="/success-reset" exact component={SucessReset} />
      <Route path="/reset-password" exact component={ResetPassword} />
    </BrowserRouter>
  );
}

export default Routes;
