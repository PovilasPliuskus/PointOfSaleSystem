import React from "react";
import { TaxObject } from "../../scripts/interfaces";
import TaxExpendedRowDetails from "./TaxExpandedRowDetails";

interface TaxTableProps {
  taxes: TaxObject[];
  paginatedTaxes: TaxObject[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedTax: TaxObject | null;

  handleRowClick: (index: number, taxId: string) => void;
  handleEditClick: (taxId: string) => void;
  handleDeleteClick: (taxId: string) => void;
}

const TaxTable: React.FC<TaxTableProps> = ({
  taxes,
  paginatedTaxes,
  currentPage,
  pageSize,
  expandedRow,
  selectedTax,

  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Tax Name</th>
        </tr>
      </thead>
      <tbody>
        {paginatedTaxes.map((tax, index) => {
          const globalIndex = (currentPage - 1) * pageSize + index;
          return (
            <React.Fragment key={tax.id}>
              <tr
                onClick={() => handleRowClick(globalIndex, tax.id)}
                style={{ cursor: "pointer" }}
              >
                <th scope="row">{globalIndex + 1}</th>
                <td>{tax.name}</td>
              </tr>

              {expandedRow === globalIndex && selectedTax && (
                <TaxExpendedRowDetails
                  selectedTax={selectedTax}
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

export default TaxTable;
