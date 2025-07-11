        public string AllocateEntityToAuditor(int entityId, int auditorPpno, int assignedBy)
            {
            string remarks = "";
            var con = this.DatabaseConnection(); con.Open();
            using (OracleCommand cmd = con.CreateCommand())
                {
                cmd.CommandText = "PKG_AD.P_ALLOCATE_ENTITY_TO_AUDITOR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.Add("p_entity_id", OracleDbType.Int32).Value = entityId;
                cmd.Parameters.Add("p_auditor_ppno", OracleDbType.Int32).Value = auditorPpno;
                cmd.Parameters.Add("p_assigned_by", OracleDbType.Int32).Value = assignedBy;
                cmd.Parameters.Add("p_remarks", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                var val = cmd.Parameters["p_remarks"].Value;
                if (val != null && val != DBNull.Value)
                    remarks = val.ToString();
                }
            con.Dispose();
            return remarks;
            }

