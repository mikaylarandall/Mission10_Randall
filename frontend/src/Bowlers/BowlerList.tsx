import { useEffect, useState } from 'react';
import { Bowler } from '../types/Bowler';

function BowlerList() {
  const [bowlerData, setBowlerData] = useState<Bowler[]>([]);

  useEffect(() => {
    const fetchFoodData = async () => {
      const rsp = await fetch('http://localhost:5201/Bowler');
      const b = await rsp.json();
      setBowlerData(b);
    };
    fetchFoodData();
  }, []);

  return (
    <>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Bowler Name:</th>
            <th>Team Name:</th>
            <th>Address:</th>
            <th>City:</th>
            <th>State:</th>
            <th>Zip Code:</th>
            <th>Phone Number:</th>
          </tr>
        </thead>
        <tbody>
          {bowlerData.map((b) => (
            <tr key={b.bowlerId}>
              <td>
                {b.bowlerLastName}, {b.bowlerFirstName}, {b.bowlerMiddleInit}
              </td>
              <td>{b.team.teamName}</td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default BowlerList;
