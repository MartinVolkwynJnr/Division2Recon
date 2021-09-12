import React from "react";
import PropTypes from "prop-types";
import Table from "react-bootstrap/Table";

const Process = ({ process }) => {
  return (
    <div>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>CustomerId</th>
            <th>CustomerName</th>
            <th>MachineNr</th>
            <th>MachineId</th>
            <th>MachineTypeSerial</th>
            <th>Process</th>
            <th>ProcessTime</th>
            <th>SensorData</th>
            <th>OnlineFrom</th>
          </tr>
        </thead>
        <tbody>
          {            
            <tr key={process.customerId}>
                <td>{process.customerId}</td>
                <td>{process.customerName}</td>
                <td>{process.machineNr}</td>
                <td>{process.machineId}</td>
                <td>{process.machineTypeSerial}</td>
                <td>{process.process}</td>
                <td>{process.processTime}</td>
                <td>{process.sensorData}</td>
                <td>{process.onlineFrom}</td>
            </tr>
          }
        </tbody>
      </Table>
    </div>
  );
};

Process.propTypes = {
  processes: PropTypes.array.isRequired
};

export default Process;
