import Cookies from "js-cookie";

export const addAuthHeader = () => {
  const token = Cookies.get("authToken");
  if (token) {
    return { Authorization: `Bearer ${token}` };
  }
  return undefined;
};
