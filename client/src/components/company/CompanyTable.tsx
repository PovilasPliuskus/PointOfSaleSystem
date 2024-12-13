import React from "react";
import { Company } from "./interfaces";
import CompanyExpendedRowDetails from "./CompanyExpandedRowDetails";

interface CompanyTableProps {
  companies: Company[];
  paginatedCompanies: Company[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedCompany: Company | null;

  handleRowClick: (index: number, companyId: string) => void;
  handleEditClick: (companyId: string) => void;
  handleDeleteClick: (companyId: string) => void;
}

const CompanyTable: React.FC<CompanyTableProps> = ({
  companies,
  paginatedCompanies,
  currentPage,
  pageSize,
  expandedRow,
  selectedCompany,

  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Company Name</th>
        </tr>
      </thead>
      <tbody>
        {paginatedCompanies.map((company, index) => {
          const globalIndex = (currentPage - 1) * pageSize + index;
          return (
            <React.Fragment key={company.id}>
              <tr
                onClick={() => handleRowClick(globalIndex, company.id)}
                style={{ cursor: "pointer" }}
              >
                <th scope="row">{globalIndex + 1}</th>
                <td>{company.name}</td>
              </tr>

              {expandedRow === globalIndex && selectedCompany && (
                <CompanyExpendedRowDetails
                  selectedCompany={selectedCompany}
                  onEdit={handleEditClick}
                  onDelete={handleDeleteClick}
                />
              )}
            </React.Fragment>
          );
        })}
      </tbody>
    </table>
  );
};

export default CompanyTable;
