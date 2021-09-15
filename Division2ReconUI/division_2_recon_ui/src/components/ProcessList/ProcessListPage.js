import React, { useState, useEffect } from "react";
import ProcessList from "./ProcessList";
import TextInput from "../common/TextInput";
import {  getProcesses, SearchByCustomerName, SearchBySensorData } from "../../api/processesApi";

function ProcessListPage() {
  const [processes, setProcesses] = useState([]);
  const [searchString, setSearchString] = useState("");

  useEffect(() => {
    getProcesses().then(_processes => {
      setProcesses(_processes);
    });
  },[])

  function handleSearch(event) {
      setSearchString(event.target.value);
  }

  function handleClearSearch(event) {
    setSearchString("");
    getProcesses().then(_processes => {
      setProcesses(_processes);
    });
}

  function searchByCustomerName(){
    console.log("searchString searchByCustomerName",searchString);
    if(searchString !== ""){
      SearchByCustomerName(searchString).then(_processes => setProcesses(_processes));
    }
    else{
      getProcesses().then(_processes => setProcesses(_processes))
    }
    
  }

  function searchBySensorData(event){
    console.log("searchString SearchBySensorData",searchString);
    if(searchString !== ""){
      SearchBySensorData(searchString).then(_processes => setProcesses(_processes));
    }
    else{
      getProcesses().then(_processes => setProcesses(_processes))
    }
  }

  return (
    <div>
      <TextInput
        name="searchInput"
        label="Search"
        value={searchString}
        onInput={handleSearch}
        error={""}
      />
      <button onClick={searchByCustomerName}>Search CustomerName</button>
      <button onClick={searchBySensorData}>Search SensorData</button>
      <button onClick={handleClearSearch}>Clear Search</button>
      <ProcessList
        processes={processes}
      />
    </div>
  );
}

export default ProcessListPage
