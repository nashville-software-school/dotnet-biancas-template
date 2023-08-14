import { useEffect, useState } from "react";
import { Button, Input, Table } from "reactstrap";
import { getIncompleteWorkOrders } from "../../managers/workOrderManager";
import { Link } from "react-router-dom";

export default function WorkOrderList({ loggedInUser }) {
  const [workOrders, setWorkOrders] = useState([]);
  const [mechanics, setMechanics] = useState([]);

  useEffect(() => {
    getIncompleteWorkOrders().then(setWorkOrders);
  }, []);

  const assignMechanic = (workOrderId, mechanicId) => {
    console.log(`Assigned ${mechanicId} to ${workOrderId}`);
  };

  const completeWorkOrder = (workOrderId) => {
    console.log(`Completed ${workOrderId}`);
  };

  return (
    <>
      <h2>Open Work Orders</h2>
      <Link to="/workorders/create">New Work Order</Link>
      <Table>
        <thead>
          <tr>
            <th>Owner</th>
            <th>Brand</th>
            <th>Color</th>
            <th>Description</th>
            <th>DateSubmitted</th>
            <th>Mechanic</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {workOrders.map((wo) => (
            <tr key={wo.id}>
              <th scope="row">{wo.bike.owner.name}</th>
              <td>{wo.bike.brand}</td>
              <td>{wo.bike.color}</td>
              <td>{wo.description}</td>
              <td>{new Date(wo.dateInitiated).toLocaleDateString()}</td>
              <td>
                {wo.userProfile
                  ? `${wo.userProfile.firstName} ${wo.userProfile.lastName}`
                  : "unassigned"}
              </td>
              <td>
                {wo.userProfile ? (
                  <Button
                    onClick={() => completeWorkOrder(wo.id)}
                    color="success"
                  >
                    Mark as Complete
                  </Button>
                ) : (
                  <Input
                    type="select"
                    onChange={(e) => {
                      assignMechanic(wo.id, parseInt(e.target.value));
                    }}
                  >
                    <option value="0">Choose mechanic</option>
                    {mechanics.map((m) => (
                      <option
                        value={m.id}
                      >{`${m.firstName} ${m.lastName}`}</option>
                    ))}
                  </Input>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
}
