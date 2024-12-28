import React, { useEffect, useState } from "react";
import { postReview, fetchSights } from "../services/sights";
import Sight from "../components/Sight";
import vtbImg from "../images/vtb.jpg";

function SightsSeaction() {
  const [sights, setSights] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      let sights = await fetchSights();
      setSights(sights);
    };
    fetchData();
  }, []);

  const onPostReview = async (review) => {
    await postReview(review);
    let sights = await fetchSights();
    setSights(sights);
  };

  return (
    <section className="p-8 flex flex-row justify-start items-start gap-12">
      <div
        className="flex flex-col w-1/3"
        style={{ maxHeight: "667px", overflowY: "auto" }}
      >
        <ul className="flex flex-col gap-5">
          {sights.map((s) => {
            return (
              <li key={s.id}>
                <Sight sight={s} onPostReview={onPostReview}></Sight>
              </li>
            );
          })}
        </ul>
      </div>
      <div
        style={{
          backgroundImage: `url(${vtbImg})`,
          height: "667px",
          width: "100%",
          backgroundSize: "cover",
          backgroundPosition: "center",
          backgroundRepeat: "no-repeat",
          position: "relative",
        }}
      ></div>
    </section>
  );
}

export default SightsSeaction;
