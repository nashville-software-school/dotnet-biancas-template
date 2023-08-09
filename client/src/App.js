import { useEffect, useState } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Route, Routes } from "react-router-dom";
import Bikes from "./components/bikes/Bikes";
import { tryGetLoggedInUser } from "./managers/authManager";
import { Spinner } from "reactstrap";
import NavBar from "./components/NavBar";
import { AuthorizedRoute } from "./components/AuthorizedRoute";
import Login from "./components/Login";
import Register from "./components/Register";

function App() {
  const [loggedInUser, setLoggedInUser] = useState();

  useEffect(() => {
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <Spinner />;
  }

  return (
    <>
      <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
      <Routes>
        <Route path="/">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <Bikes />
              </AuthorizedRoute>
            }
          />
          <Route
            path="bikes"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <Bikes />
              </AuthorizedRoute>
            }
          />
          <Route
            path="workorders"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <p>Work Orders</p>
              </AuthorizedRoute>
            }
          />
          <Route
            path="employees"
            element={
              <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                <p>Employees</p>
              </AuthorizedRoute>
            }
          />
          <Route
            path="login"
            element={<Login setLoggedInUser={setLoggedInUser} />}
          />
          <Route
            path="register"
            element={<Register setLoggedInUser={setLoggedInUser} />}
          />
        </Route>
        <Route path="*" element={<p>Whoops, nothing here...</p>} />
      </Routes>
    </>
  );
}

export default App;
