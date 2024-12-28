import axios from "axios";

export const fetchSights = async () => {
  let response = await axios.get("http://localhost:5179/Sight");

  return response.data;
};

export const postReview = async (review) => {
  let response = await axios.post("http://localhost:5179/Review", review, {
    withCredentials: true,
  });

  return response.status;
};
