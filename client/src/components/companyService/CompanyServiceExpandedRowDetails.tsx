import { CompanyServiceObject } from "../../scripts/interfaces";

interface CompanyServiceExpandedRowDetailsProps {
  selectedCompanyService: CompanyServiceObject;
  onEdit: (companyServiceId: string) => void;
  onDelete: (companyServiceId: string) => void;
}

const CompanyServiceExpandedRowDetails: React.FC<
  CompanyServiceExpandedRowDetailsProps
> = ({ selectedCompanyService, onDelete, onEdit }) => {
  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>CompanyService Name:</strong> {selectedCompanyService.name}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(selectedCompanyService.receiveTime).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedCompanyService.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedCompanyService.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedCompanyService.modifiedByEmployeeId}
          </p>
          <div className="mt-2">
            <button
              className="btn btn-warning me-2"
              onClick={() => onEdit(selectedCompanyService.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              onClick={() => onDelete(selectedCompanyService.id)}
            >
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default CompanyServiceExpandedRowDetails;
