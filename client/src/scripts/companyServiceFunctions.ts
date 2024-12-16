import {
  CompanyServiceObject,
  UpdateCompanyServiceRequest,
} from "./interfaces";

export const fetchAllCompanyServices = async (): Promise<any> => {
  try {
    const response = await fetch("https://localhost:44309/api/companyService", {
      method: "GET",
      credentials: "include",
    });

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log(
      "Retrieved response calling fetchAllCompanyServices: ",
      response
    );

    return await response.json();
  } catch (error) {
    console.error("Error in fetchAllCompanyServices: ", error);
    throw error;
  }
};

export const fetchCompanyService = async (
  companyServiceId: string
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/companyService/${companyServiceId}`,
      {
        method: "GET",
        credentials: "include",
      }
    );

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchCompanyService: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteCompanyService = async (
  companyServiceId: string
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/companyService/${companyServiceId}`,
      {
        method: "DELETE",
        credentials: "include",
      }
    );

    if (!response.ok) {
      console.error(`Error deleting companyService: ${response.statusText}`);
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deleting companyService:", error);
    return { success: false };
  }
};

export const UpdateCompanyService = async (
  updateCompanyServiceRequest: UpdateCompanyServiceRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/companyService/${updateCompanyServiceRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(updateCompanyServiceRequest),
      }
    );

    if (!response.ok) {
      console.error(`Error updateing companyService: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("CompanyService updated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing companyService", error);
    return { success: false };
  }
};

export const AddCompanyService = async (
  newCompanyService: CompanyServiceObject
): Promise<any> => {
  try {
    const response = await fetch(`https://localhost:44309/api/companyService`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newCompanyService),
    });

    if (!response.ok) {
      console.error(`Error adding companyService: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("companyService added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding companyService", error);
    return { success: false };
  }
};
