export const fetchAllCompanies = async (): Promise<any> => {
  try {
    const response = await fetch("https://localhost:44309/api/company", {
      method: "GET",
      credentials: "include",
    });

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchAllCompanies: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error in fetchAllCompanies: ", error);
    throw error;
  }
};

export const fetchCompany = async (companyId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/company/${companyId}`,
      {
        method: "GET",
        credentials: "include",
      }
    );

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchCompany: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};
