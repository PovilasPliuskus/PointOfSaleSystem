// import React, { useState, useEffect } from "react";
// import Pagination from "../Pagination";
// import "bootstrap/dist/css/bootstrap.min.css";
// import { v4 as uuidv4 } from "uuid";
// import { Company, CompanyDetails, UpdateCompanyRequest } from "./interfaces";
// import {
//   addCompany,
//   deleteObjectById,
//   fetchAllData,
//   fetchObjectById,
//   UpdateCompany,
// } from "../../scripts/utility-functions";
// import CompanyExpendedRowDetails from "./CompanyExpandedRowDetails";
// import AddCompanyModal from "./AddCompanyModal";

// function Companies() {
//   const [currentPage, setCurrentPage] = useState(1);
//   const [pageSize, setPageSize] = useState(5);
//   const [companies, setCompanies] = useState<Company[]>([]);
//   const [loading, setLoading] = useState(true);
//   const [expandedRow, setExpandedRow] = useState<number | null>(null);
//   const [selectedCompanyDetails, setSelectedCompanyDetails] =
//     useState<CompanyDetails | null>(null);

//   const [showSaveModal, setShowSaveModal] = useState(false);
//   const [newCompanyCode, setNewCompanyCode] = useState("");
//   const [newCompanyName, setNewCompanyName] = useState("");

//   const [showEditModal, setShowEditModal] = useState(false);

//   const baseUrl = "https://localhost:44309/api";

//   useEffect(() => {
//     const loadCompanies = async () => {
//       try {
//         setLoading(true);
//         const data = await fetchAllData(baseUrl + "/company");
//         console.log(data);
//         setCompanies(data);
//       } catch (error) {
//         console.error("Error loading companies:", error);
//       } finally {
//         setLoading(false);
//       }
//     };
//     loadCompanies();
//   }, []);

//   const toggleAddNewCompanyModal = () => {
//     setShowSaveModal(!showSaveModal);
//     setNewCompanyCode("");
//     setNewCompanyName("");
//   };

//   const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
//     const { name, value } = e.target;
//     if (name === "code") setNewCompanyCode(value);
//     if (name === "name") setNewCompanyName(value);
//   };

//   const handleRowClick = async (index: number, companyId: string) => {
//     setExpandedRow(expandedRow === index ? null : index);

//     if (expandedRow !== index) {
//       try {
//         const companyDetails = await fetchObjectById(
//           baseUrl + `/company/${companyId}`
//         );
//         console.log("Fetched company details:", companyDetails);
//         setSelectedCompanyDetails(companyDetails);
//       } catch (error) {
//         console.error("Error fetching company details:", error);
//       }
//     }
//   };

//   const handleSaveCompany = async () => {
//     try {
//       if (isEditMode && selectedCompanyDetails) {
//         // Edit mode logic
//         const updatedCompany: UpdateCompanyRequest = {
//           id: selectedCompanyDetails.id,
//           code: newCompanyCode,
//           name: newCompanyName,
//           updateTime: new Date().toISOString(),
//         };

//         const { success, data } = await UpdateCompany(
//           baseUrl + `/company/${updatedCompany.id}`,
//           updatedCompany
//         );

//         if (!success) {
//           alert("Failed to update company");
//           return;
//         }

//         alert("Company updated successfully");
//       } else {
//         // Add new company logic
//         const newCompany = {
//           id: uuidv4(),
//           code: newCompanyCode,
//           name: newCompanyName,
//           receiveTime: new Date().toISOString(),
//           updateTime: new Date().toISOString(),
//           createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
//           modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
//           establishments: [],
//           companyProducts: [],
//           companyServices: [],
//         };

//         const { success, data } = await addCompany(
//           baseUrl + "/company",
//           newCompany
//         );

//         if (!success) {
//           alert("Failed to add company");
//           return;
//         }

//         alert("Company added successfully");
//       }

//       // Refresh the list of companies
//       const updatedCompanies = await fetchAllData(baseUrl + "/company");
//       setCompanies(updatedCompanies);

//       // Close the modal and reset state
//       toggleAddNewCompanyModal();
//     } catch (error) {
//       console.error("Error saving company:", error);
//       alert("An error occurred while saving the company");
//     }
//   };

//   const handleEdit = () => {
//     if (selectedCompanyDetails) {
//       setNewCompanyCode(selectedCompanyDetails.code);
//       setNewCompanyName(selectedCompanyDetails.name);
//       setShowSaveModal(true); // Open modal in edit mode
//     }
//   };

//   const handleDelete = async () => {
//     if (selectedCompanyDetails) {
//       const confirmDelete = window.confirm(
//         `Are you sure you want to delete ${selectedCompanyDetails.name}?`
//       );

//       if (confirmDelete) {
//         try {
//           await deleteObjectById(
//             baseUrl + `/company/${selectedCompanyDetails.id}`
//           );

//           alert("Company deleted successfully.");

//           const updatedCompanies = await fetchAllData(baseUrl + "/company");
//           setCompanies(updatedCompanies);
//           setSelectedCompanyDetails(null);
//         } catch (error) {
//           console.error("Error deleting company:", error);
//           alert("Failed to delete company.");
//         }
//       }
//     }
//   };

//   const paginatedCompanies = companies.slice(
//     (currentPage - 1) * pageSize,
//     currentPage * pageSize
//   );

//   return (
//     <>
//       <h1 className="text-center mb-4">Companies</h1>
//       <div className="container mt-4">
//         {loading ? (
//           <div className="text-center">Loading...</div>
//         ) : (
//           <table className="table table-striped">
//             <thead>
//               <tr>
//                 <th scope="col">#</th>
//                 <th scope="col">Company Name</th>
//               </tr>
//             </thead>
//             <tbody>
//               {paginatedCompanies.map((company, index) => {
//                 const globalIndex = (currentPage - 1) * pageSize + index;
//                 return (
//                   <React.Fragment key={company.id}>
//                     <tr
//                       onClick={() => handleRowClick(globalIndex, company.id)}
//                       style={{ cursor: "pointer" }}
//                     >
//                       <th scope="row">{globalIndex + 1}</th>
//                       <td>{company.name}</td>
//                     </tr>

//                     {expandedRow === globalIndex && selectedCompanyDetails && (
//                       <CompanyExpendedRowDetails
//                         companyDetails={selectedCompanyDetails}
//                         onEdit={handleEdit}
//                         onDelete={handleDelete}
//                       />
//                     )}
//                   </React.Fragment>
//                 );
//               })}
//             </tbody>
//           </table>
//         )}
//         <Pagination
//           currentPage={currentPage}
//           totalPages={Math.ceil(companies.length / pageSize)}
//           totalItems={companies.length}
//           pageSize={pageSize}
//           onPageChange={setCurrentPage}
//           onPageSizeChange={setPageSize}
//         />
//         <div className="d-flex justify-content-end mt-3">
//           <button
//             className="btn btn-success btn-lg"
//             onClick={toggleAddNewCompanyModal}
//           >
//             Add Company
//           </button>
//         </div>
//       </div>
//       <AddCompanyModal
//         showModal={showSaveModal}
//         toggleModal={toggleAddNewCompanyModal}
//         handleSave={handleSaveCompany}
//         newCompanyCode={newCompanyCode}
//         newCompanyName={newCompanyName}
//         handleInputChange={handleInputChange}
//         isEditMode={!!selectedCompanyDetails}
//       />
//     </>
//   );
// }

function Companies() {
  return <></>;
}

export default Companies;
