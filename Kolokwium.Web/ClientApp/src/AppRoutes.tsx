import React from "react";
import { Counter } from "./components/Counter";
import { Home } from "./components/Home";
import { MuiTest } from "./components/MuiTest";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/mui-test',
    element: <MuiTest />
  }
];

export default AppRoutes;
