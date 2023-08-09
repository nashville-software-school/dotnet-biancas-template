import { useState, useEffect } from "react";
import BikeCard from "./BikeCard";

export default function BikeList({ setDetailsBikeId }) {
  const [bikes, setBikes] = useState([]);

  const getAllBikes = () => {
    //implement functionality here...
  };

  useEffect(() => {
    getAllBikes();
  }, []);
  return (
    <>
      <h2>Bikes</h2>
      {/* Use BikeCard component here to list bikes...*/}
    </>
  );
}
