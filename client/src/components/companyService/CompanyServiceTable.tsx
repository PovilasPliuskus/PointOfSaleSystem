import { CompanyServiceObject } from "../../scripts/interfaces";
import React from "react";
import CompanyServiceExpandedRowDetails from "./CompanyServiceExpandedRowDetails";

interface CompanyServiceTableProps {
  companyServices: CompanyServiceObject[];
  paginatedCompanyServices: CompanyServiceObject[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedCompanyService: CompanyServiceObject | null;

  handleRowClick: (index: number, companyServiceId: string) => void;
  handleEditClick: (companyServiceId: string) => void;
  handleDeleteClick: (companyServiceId: string) => void;
}

const CompanyServiceTable: React.FC<CompanyServiceTableProps> = ({
  companyServices,
  paginatedCompanyServices,
  currentPage,
  pageSize,
  expandedRow,
  selectedCompanyService,
  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Company Service Name</th>
        </tr>
      </thead>
      <tbody>
        {paginatedCompanyServices.map((companyService, index) => {
          const globalIndex = (currentPage - 1) * pageSize + index;
          return (
            <React.Fragment key={companyService.id}>
              <tr
                onClick={() => handleRowClick(globalIndex, companyService.id)}
                style={{ cursor: "pointer" }}
              >
                <th scope="row">{globalIndex + 1}</th>
                <td>{companyService.name}</td>
              </tr>

              {expandedRow === globalIndex && selectedCompanyService && (
                <CompanyServiceExpandedRowDetails
                  selectedCompanyService={selectedCompanyService}
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

export default CompanyServiceTable;
