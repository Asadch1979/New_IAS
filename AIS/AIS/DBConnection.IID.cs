using AIS.Models.IID;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace AIS.Controllers
    {
    public partial class DBConnection
        {
        public int SubmitComplaint(ComplaintModel model)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.ADD_COMPLAINT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_nature", OracleDbType.Varchar2).Value = model.Nature ?? string.Empty;
                cmd.Parameters.Add("p_contents", OracleDbType.Clob).Value = model.Contents ?? string.Empty;
                cmd.Parameters.Add("p_uploaded_complaint", OracleDbType.Varchar2).Value = model.UploadedComplaint ?? string.Empty;
                cmd.Parameters.Add("p_uploaded_ffr", OracleDbType.Varchar2).Value = model.UploadedFFR ?? string.Empty;
                cmd.Parameters.Add("p_uploaded_evidence", OracleDbType.Varchar2).Value = model.UploadedEvidence ?? string.Empty;
                cmd.Parameters.Add("p_action_required", OracleDbType.Varchar2).Value = model.ActionRequired ?? string.Empty;
                cmd.Parameters.Add("p_submitted_by", OracleDbType.Int32).Value = model.SubmittedBy;
                cmd.Parameters.Add("o_complaint_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var id = Convert.ToInt32(cmd.Parameters["o_complaint_id"].Value.ToString());
                con.Dispose();
                return id;
                }
            }

        public DataTable GetComplaintsByUser(int userId)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.GET_COMPLAINTS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_user_id", OracleDbType.Int32).Value = userId;
                cmd.Parameters.Add("io_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                var dt = new DataTable();
                using (var rdr = cmd.ExecuteReader())
                    {
                    dt.Load(rdr);
                    }
                con.Dispose();
                return dt;
                }
            }

        public int AddAssessment(AssessmentModel model)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.ADD_ASSESSMENT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_complaint_id", OracleDbType.Int32).Value = model.ComplaintId;
                cmd.Parameters.Add("p_received_by", OracleDbType.Int32).Value = model.ReceivedBy;
                cmd.Parameters.Add("p_assessment", OracleDbType.Clob).Value = model.Assessment ?? string.Empty;
                cmd.Parameters.Add("p_recommendation", OracleDbType.Varchar2).Value = model.Recommendation ?? string.Empty;
                cmd.Parameters.Add("o_assessment_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var id = Convert.ToInt32(cmd.Parameters["o_assessment_id"].Value.ToString());
                con.Dispose();
                return id;
                }
            }

        public int AddHeadReview(HeadReviewModel model)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.ADD_HEAD_REVIEW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_complaint_id", OracleDbType.Int32).Value = model.ComplaintId;
                cmd.Parameters.Add("p_assessment_id", OracleDbType.Int32).Value = model.AssessmentId;
                cmd.Parameters.Add("p_reviewed_by", OracleDbType.Int32).Value = model.ReviewedBy;
                cmd.Parameters.Add("p_directions", OracleDbType.Clob).Value = model.Directions ?? string.Empty;
                cmd.Parameters.Add("p_assigned_to_unit", OracleDbType.Int32).Value = model.AssignedToUnit;
                cmd.Parameters.Add("p_referred_back_comments", OracleDbType.Clob).Value = model.ReferredBackComments ?? string.Empty;
                cmd.Parameters.Add("p_action", OracleDbType.Varchar2).Value = model.Action ?? string.Empty;
                cmd.Parameters.Add("o_review_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var id = Convert.ToInt32(cmd.Parameters["o_review_id"].Value.ToString());
                con.Dispose();
                return id;
                }
            }

        public int AddInvestigationPlan(InvestigationPlanModel model)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.ADD_INV_PLAN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_complaint_id", OracleDbType.Int32).Value = model.ComplaintId;
                cmd.Parameters.Add("p_plan_details", OracleDbType.Clob).Value = model.PlanDetails ?? string.Empty;
                cmd.Parameters.Add("p_submitted_by", OracleDbType.Int32).Value = model.SubmittedBy;
                cmd.Parameters.Add("p_status", OracleDbType.Varchar2).Value = model.Status ?? string.Empty;
                cmd.Parameters.Add("o_plan_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var id = Convert.ToInt32(cmd.Parameters["o_plan_id"].Value.ToString());
                con.Dispose();
                return id;
                }
            }

        public int AddPlanApproval(PlanApprovalModel model)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.ADD_PLAN_APPROVAL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_plan_id", OracleDbType.Int32).Value = model.PlanId;
                cmd.Parameters.Add("p_approved_by", OracleDbType.Int32).Value = model.ApprovedBy;
                cmd.Parameters.Add("p_is_approved", OracleDbType.Varchar2).Value = model.IsApproved ?? string.Empty;
                cmd.Parameters.Add("p_edited_plan", OracleDbType.Clob).Value = model.EditedPlan ?? string.Empty;
                cmd.Parameters.Add("p_further_actions", OracleDbType.Clob).Value = model.FurtherActions ?? string.Empty;
                cmd.Parameters.Add("o_approval_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var id = Convert.ToInt32(cmd.Parameters["o_approval_id"].Value.ToString());
                con.Dispose();
                return id;
                }
            }

        public int AddInquiryReport(InquiryReportModel model)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.ADD_INQUIRY_REPORT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_complaint_id", OracleDbType.Int32).Value = model.ComplaintId;
                cmd.Parameters.Add("p_name_complainant", OracleDbType.Varchar2).Value = model.NameComplainant ?? string.Empty;
                cmd.Parameters.Add("p_name_accused", OracleDbType.Varchar2).Value = model.NameAccused ?? string.Empty;
                cmd.Parameters.Add("p_gist", OracleDbType.Clob).Value = model.Gist ?? string.Empty;
                cmd.Parameters.Add("p_proceedings", OracleDbType.Clob).Value = model.Proceedings ?? string.Empty;
                cmd.Parameters.Add("p_findings", OracleDbType.Clob).Value = model.Findings ?? string.Empty;
                cmd.Parameters.Add("p_recommendation", OracleDbType.Clob).Value = model.Recommendation ?? string.Empty;
                cmd.Parameters.Add("p_uploaded_report", OracleDbType.Varchar2).Value = model.UploadedReport ?? string.Empty;
                cmd.Parameters.Add("p_uploaded_evidence", OracleDbType.Varchar2).Value = model.UploadedEvidence ?? string.Empty;
                cmd.Parameters.Add("p_submitted_on", OracleDbType.Date).Value = model.SubmittedOn;
                cmd.Parameters.Add("p_submitted_by", OracleDbType.Int32).Value = model.SubmittedBy;
                cmd.Parameters.Add("o_report_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var id = Convert.ToInt32(cmd.Parameters["o_report_id"].Value.ToString());
                con.Dispose();
                return id;
                }
            }

        public int AddAnalysis(AnalysisModel model)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.ADD_ANALYSIS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_report_id", OracleDbType.Int32).Value = model.ReportId;
                cmd.Parameters.Add("p_policy_gaps", OracleDbType.Clob).Value = model.PolicyGaps ?? string.Empty;
                cmd.Parameters.Add("p_control_gaps", OracleDbType.Clob).Value = model.ControlGaps ?? string.Empty;
                cmd.Parameters.Add("p_procedural_violations", OracleDbType.Clob).Value = model.ProceduralViolations ?? string.Empty;
                cmd.Parameters.Add("p_forward_to", OracleDbType.Varchar2).Value = model.ForwardTo ?? string.Empty;
                cmd.Parameters.Add("p_comments", OracleDbType.Clob).Value = model.Comments ?? string.Empty;
                cmd.Parameters.Add("p_analyzed_by", OracleDbType.Int32).Value = model.AnalyzedBy;
                cmd.Parameters.Add("o_analysis_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var id = Convert.ToInt32(cmd.Parameters["o_analysis_id"].Value.ToString());
                con.Dispose();
                return id;
                }
            }

        public int AddFinalApproval(FinalApprovalModel model)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.ADD_FINAL_APPROVAL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_report_id", OracleDbType.Int32).Value = model.ReportId;
                cmd.Parameters.Add("p_comments", OracleDbType.Clob).Value = model.Comments ?? string.Empty;
                cmd.Parameters.Add("p_approved", OracleDbType.Varchar2).Value = model.Approved ?? string.Empty;
                cmd.Parameters.Add("p_approved_by", OracleDbType.Int32).Value = model.ApprovedBy;
                cmd.Parameters.Add("o_final_approval_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var id = Convert.ToInt32(cmd.Parameters["o_final_approval_id"].Value.ToString());
                con.Dispose();
                return id;
                }
            }

        public int AddCaseStudy(CaseStudyModel model)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.ADD_CASE_STUDY";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_complaint_id", OracleDbType.Int32).Value = model.ComplaintId;
                cmd.Parameters.Add("p_origin_process_owner", OracleDbType.Varchar2).Value = model.OriginProcessOwner ?? string.Empty;
                cmd.Parameters.Add("p_name_complainant", OracleDbType.Varchar2).Value = model.NameComplainant ?? string.Empty;
                cmd.Parameters.Add("p_branch", OracleDbType.Varchar2).Value = model.Branch ?? string.Empty;
                cmd.Parameters.Add("p_gist", OracleDbType.Clob).Value = model.Gist ?? string.Empty;
                cmd.Parameters.Add("p_outcome", OracleDbType.Clob).Value = model.Outcome ?? string.Empty;
                cmd.Parameters.Add("p_modus_operandi", OracleDbType.Clob).Value = model.ModusOperandi ?? string.Empty;
                cmd.Parameters.Add("p_gaps", OracleDbType.Clob).Value = model.Gaps ?? string.Empty;
                cmd.Parameters.Add("p_root_cause", OracleDbType.Clob).Value = model.RootCause ?? string.Empty;
                cmd.Parameters.Add("p_actions_rec", OracleDbType.Clob).Value = model.ActionsRec ?? string.Empty;
                cmd.Parameters.Add("p_status", OracleDbType.Varchar2).Value = model.Status ?? string.Empty;
                cmd.Parameters.Add("o_case_id", OracleDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var id = Convert.ToInt32(cmd.Parameters["o_case_id"].Value.ToString());
                con.Dispose();
                return id;
                }
            }

        public DataTable GetReports(ReportFilterModel filter)
            {
            sessionHandler = new SessionHandler();
            sessionHandler._httpCon = this._httpCon;
            sessionHandler._session = this._session;
            sessionHandler._configuration = this._configuration;
            var con = this.DatabaseConnection();
            con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_INQ.GET_REPORTS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_filter", OracleDbType.Varchar2).Value = filter?.Nature ?? string.Empty;
                cmd.Parameters.Add("io_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                var dt = new DataTable();
                using (var rdr = cmd.ExecuteReader())
                    {
                    dt.Load(rdr);
                    }
                con.Dispose();
                return dt;
                }
            }
        }
    }
