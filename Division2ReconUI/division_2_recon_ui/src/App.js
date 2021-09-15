import React from "react";
import { Route, Switch } from "react-router-dom";
import './App.css';
import ProcessListPage from './components/ProcessList/ProcessListPage';
import ProcessPage from './components/Process/ProcessPage';
import Header from "./components/common/Header";
import PageNotFound from "./components/PageNotFound";
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <div className="container-fluid">
      <Header />
      <Switch>
        <Route exact path="/" component={ProcessListPage} />
        <Route exact path="/process/:process" component={ProcessPage} />
        <Route component={PageNotFound} />
      </Switch>
    
  </div>
  );
}

export default App;
