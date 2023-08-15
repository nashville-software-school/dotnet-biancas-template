import { useEffect, useState } from "react";
import { Button, Table } from "reactstrap";
import { Link } from "react-router-dom";
import {
  demoteUser,
  getUserProfilesWithRoles,
  promoteUser,
} from "../../managers/userProfileManager";

export default function UserProfileList({ loggedInUser }) {
  const [userProfiles, setUserProfiles] = useState([]);

  useEffect(() => {
    getUserProfilesWithRoles().then(setUserProfiles);
  }, []);

  const promote = (id) => {
    promoteUser(id).then(() => {
      getUserProfilesWithRoles().then(setUserProfiles);
    });
  };
  const demote = (id) => {
    demoteUser(id).then(() => {
      getUserProfilesWithRoles().then(setUserProfiles);
    });
  };

  return (
    <>
      <h2>Open Work Orders</h2>
      <Link to="/workorders/create">New Work Order</Link>
      <Table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Address</th>
            <th>Email</th>
            <th>Username</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {userProfiles.map((up) => (
            <tr key={up.id}>
              <th scope="row">{`${up.firstName} ${up.lastName}`}</th>
              <td>{up.address}</td>
              <td>{up.email}</td>
              <td>{up.userName}</td>
              <td>
                {up.roles.includes("Admin") ? (
                  <Button
                    color="danger"
                    onClick={() => {
                      demote(up.identityUserId);
                    }}
                  >
                    Demote
                  </Button>
                ) : (
                  <Button
                    color="success"
                    onClick={() => {
                      promote(up.identityUserId);
                    }}
                  >
                    Promote
                  </Button>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
}
