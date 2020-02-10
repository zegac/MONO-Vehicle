import React from "react";
import { Switch, Route, BrowserRouter } from "react-router-dom";
// Your component imports. Will probably be different
import { Home } from "./pages/home";
import { VehicleMakeList, VehicleMakeEdit } from "./pages/make";
import { VehicleModelList, VehicleModelEdit } from "./pages/model";

export default function(props) {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path={["/", "/home"]}>
          <Home />
        </Route>
        <Route path="/makes">
          <VehicleMakeList />
        </Route>
        <Route path="/makes/:id">
          <VehicleMakeEdit />
        </Route>
        <Route path="/models">
          <VehicleModelList />
        </Route>
        <Route path="/models/:id">
          <VehicleModelEdit />
        </Route>
      </Switch>
    </BrowserRouter>
  );
}
