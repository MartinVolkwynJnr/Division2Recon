import React, {useState, useEffect} from "react";
import { getProcess } from "../../api/processesApi";
import Process from "./Process";

const getProcessName = thePath => thePath.substring(thePath.lastIndexOf('/') + 1)

function ProcessPage() {
  
  const [process, setProcess] = useState([]);
  
  useEffect(() => {
    var thePath = getProcessName(window.location.href);
    console.log("the path", thePath);
    getProcess(thePath).then(_process => setProcess(_process));
  }, []);

  return (
    <div>
        <Process process={process}/>
      </div>
  );
}
export default ProcessPage