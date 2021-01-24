using FluentMigrator;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Configuration;

namespace Recruit.Models
{
    [Migration(20201117141200)]
    public class CreateTables : Migration
    {


        public override void Up()
        {


            Create.Table("tbl_logins").WithDescription("Table to Store the Login credentials")
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_logins_id").WithColumnDescription("Primary key id").Identity()//Creation of tbl_logins
                .WithColumn("user_id").AsString(20).WithColumnDescription("Userid for login").Unique("UK_tbl_logins_user_id")
                .WithColumn("first_name").AsString(50).NotNullable().WithColumnDescription("First name of the user for login")
                .WithColumn("last_name").AsString(50).NotNullable().WithColumnDescription("Last name of the user for login")
                .WithColumn("password").AsString(16).NotNullable().WithColumnDescription("Password of specific user");

            Create.Table("tbl_employees").WithDescription("Table used to keep track of the Employee invovled")                       //Creation of tbl_employees
                 .WithColumn("id").AsInt64().Identity().PrimaryKey("PK_tbl_employees_Id").WithColumnDescription("Primary key")
                .WithColumn("code").AsString(5).WithColumnDescription("code of the employee")
                .WithColumn("name").AsString(50).NotNullable().WithColumnDescription("Name of the Employee");

            Create.Table("tbl_sources").WithDescription("Table used to store details About applicants Source")                           //Creation of tbl_sources
               .WithColumn("id").AsInt64().Identity().PrimaryKey("PK_tbl_sources_id").WithColumnDescription("id for the respective Source")
                .WithColumn("code").AsString(15).WithColumnDescription("Code for the respective Source").Unique("UK_tbl_sources_code")
               .WithColumn("name").AsString(25).NotNullable().WithColumnDescription("Name of the Source").Unique("UK_tbl_sources_name");

            Create.Table("tbl_locations").WithDescription("Table used to Store Locations")                                                //Creation of tbl_locations
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_Locations_Id").WithColumnDescription("id of the specific Location").Identity()
               .WithColumn("city").AsString(20).NotNullable().WithColumnDescription("Name of the city").Unique("UK_tbl_locations_city");

            Create.Table("tbl_process_statuses").WithDescription("Table used to Store interview Process statuses")                            //Creation of tbl_process_statuses
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_process_statuses_Id").WithColumnDescription("id of the specific ProcessStatuses").Identity()
               .WithColumn("code").AsString(15).NotNullable().Unique().WithColumnDescription("Code of the specified Process status").Unique("UK_tbl_process_statuses_code")
                .WithColumn("status").AsString(50).NotNullable().WithColumnDescription("Status of the round of interview").Unique("UK_tbl_process_statuses_status")
                .WithColumn("colour").AsString(10).Nullable().WithColumnDescription("Colour based on the interview status");

            Create.Table("tbl_process_stages").WithDescription("Table used to Store Interview Stages")                                       //Creation of tbl_process_stages 
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_process_stages_Id").WithColumnDescription("id of the specific ProcessStages").Identity()
               .WithColumn("code").AsString(15).Unique().NotNullable().WithColumnDescription("Code of the specified Process stages").Unique("UK_tbl_process_stages_code")
                .WithColumn("stage").AsString(50).NotNullable().WithColumnDescription("Stages of the round of interview").Unique("UK_tbl_process_stages_stage");

            Create.Table("tbl_vacancies").WithDescription("Table used to store Requirements and vacancies Details")                          //Creation of tbl_vacancies
               .WithColumn("id").AsInt64().PrimaryKey().Identity().NotNullable().PrimaryKey("PK_tbl_vacancies_id").WithColumnDescription("Code for specific Job positions")
                .WithColumn("code").AsString(15).WithColumnDescription("Code for specific Job positions").Unique("UK_tbl_Vacancies_code")
               .WithColumn("name").AsString(50).NotNullable().WithColumnDescription("Name of the Position that is open for applicant/Company Requirements").Unique("UK_tbl_vacancies_name")
                .WithColumn("vacancy").AsInt64().Nullable().WithColumnDescription("Vacancies in the specified field");

            Create.Table("tbl_interview_round_statuses").WithDescription("Table used to store Roundwise Interview statuses")                           //Creation of tbl_interview_round_statuses
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_interview_round_statuses_Id").WithColumnDescription("id of the specific ProcessStatuses").Identity()
                .WithColumn("status").AsString(20).NotNullable().WithColumnDescription("Status of the roundwise of interview statuses").Unique("UK_tbl_interview_round_statuses_status");

            Create.Table("tbl_owners").WithDescription("Table used to store resume owners details")                                                  //Creation of tbl_owners
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_owners_Id").WithColumnDescription("id of the specific Owner").Identity()
                .WithColumn("first_name").AsString(50).NotNullable().WithColumnDescription("FirstName of the Owners")
               .WithColumn("last_name").AsString(50).NotNullable().WithColumnDescription("LastName of the Owners");

            //Creating the Main table
            Create.Table("tbl_candidates").WithDescription("Table to Store the details of the Candidate")                            //Creation of tbl_candidates
         .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_candidates_Id").Identity().WithColumnDescription("Primary key suto incremented")
         .WithColumn("first_name").AsString(50).NotNullable().WithColumnDescription("FirstName of the Candidate")
         .WithColumn("last_name").AsString(50).NotNullable().WithColumnDescription("LastName of the Candidate")
         .WithColumn("email").AsString(50).NotNullable().WithColumnDescription("Email of the Candidate").Unique("UK_tbl_candidates_email")
         .WithColumn("phone").AsString(15).NotNullable().WithColumnDescription("Phone No of the Candidate").Unique("UK_tbl_candidates_phone")
         .WithColumn("source_code").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the Source table defines the source of the candidate resume")
         .ForeignKey("FK_tbl_candidates_tbl_sources_source_code", "tbl_sources", "id")
         .WithColumn("referral_id").AsInt64().Nullable().WithColumnDescription("Foreignkey references the tblEmployoee table defines the Id of the employee who refered the candidate")
         .ForeignKey("FK_tbl_candidates_tbl_employees_ReferralId", "tbl_employees", "id")
         .WithColumn("total_experience").AsInt64().NotNullable().WithColumnDescription("Total experience of the candidate")
         .WithColumn("relevant_experience").AsInt64().NotNullable().WithColumnDescription("Relevant Experience of the candidate")
         .WithColumn("current_employer").AsString(30).Nullable().WithColumnDescription("Current Employer of the Candidate")
         .WithColumn("current_designation").AsString().NotNullable().WithColumnDescription("Current Designation of the candidate")
         .WithColumn("position_applied_code").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_vacancies table defines the Code of the position that is vacant")
         .ForeignKey("FK_tbl_candidates_tbl_vacancies_position_applied_code", "tbl_vacancies", "id")
         .WithColumn("current_ctc").AsInt64().NotNullable().WithColumnDescription("Current ctc of the candidate")
         .WithColumn("expected_ctc").AsInt64().NotNullable().WithColumnDescription("Expected ctc of the candidate")
         .WithColumn("reason_for_change").AsString(150).Nullable().WithColumnDescription("Reason for the candidate to change")
         .WithColumn("notice_period").AsInt64().NotNullable().WithColumnDescription("Notice period if any in days/if no notice period the zero as value")
         .WithColumn("is_serving_notice").AsBoolean().NotNullable().WithColumnDescription("if the candidate is serving the notice period yes or NO as value")
         .WithColumn("last_working_day").AsDate().Nullable().WithColumnDescription("if hes serving the when will the last working day be")
         .WithColumn("current_location").AsString(30).NotNullable().WithColumnDescription("current location of the candidate")
         .WithColumn("process_stage_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_process_stages table defines the Id of the process stages")
         .ForeignKey("FK_tbl_candidates_tbl_process_stages_ProcessStageId", "tbl_process_stages", "id")
         .WithColumn("process_stage_date").AsDateTime().NotNullable().WithColumnDescription("Process Stage udpated Date")
         .WithColumn("process_start_date").AsDateTime().NotNullable().WithColumnDescription("Process Start date for the candidate used for keeping track history of the candidate for next interview")
          .WithColumn("process_end_date").AsDateTime().Nullable().WithColumnDescription("Process end date for the candidate used for keeping track of history of the candidate for next interview")
          .WithColumn("interview_status_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_process_statuses table defines the Id of the process statuses")
          .ForeignKey("FK_tbl_candidates_tbl_process_statuses_InterviewStatusId", "tbl_process_statuses", "id")
          .WithColumn("resume_owner_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_process_statuses table defines the Owner of the resume")
          .ForeignKey("FK_tbl_candidates_tbl_owners_Resume_owner_id", "tbl_owners", "id")
           .WithColumn("owner_for_reminder_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_process_statuses table defines the Owner of the resume for Reminder")
          .ForeignKey("FK_tbl_candidates_tbl_owners_OwnerForReminder", "tbl_owners", "id")
          .WithColumn("comments").AsString(150).Nullable().WithColumnDescription("Comments on the interview process")
          .WithColumn("date_of_joining").AsDate().Nullable().WithColumnDescription("date of Joining of the CAndidate")
         .WithColumn("notes").AsString(150).Nullable().WithColumnDescription("Notes about the candidate")
         .WithColumn("links_for_interview").AsString(100).Nullable().WithColumnDescription("google Meet/zoom links for interview");

            //Creation of Linked table creation

            Create.Table("tbl_preferred_locations").WithDescription("Table used to store the prefered locations as it will be multiple")                  //Creation of tbl_preferred_locations
              .WithColumn("id").AsInt64().Identity().PrimaryKey().WithColumnDescription("Primary key")
                .WithColumn("candidate_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_candidates table defines the id of the candidate")
            .ForeignKey("FK_tbl_preferred_locations_tbl_candidates_CandidateId", "tbl_candidates", "id")
            .WithColumn("location_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_locations table defines the cities")
            .ForeignKey("FK_tbl_preferred_locations_tbl_Locations_LocationId", "tbl_locations", "id");

            Create.Table("tbl_interview_details").WithDescription("Table used to store the Interview Details")
                .WithColumn("id").AsInt64().Identity().PrimaryKey().WithColumnDescription("Primary key")//Creation of tbl_interview_details

                .WithColumn("interview_stage_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_Process_stages table defines the id of the process Stage")
                 .ForeignKey("FK_tbl_interview_details_tbl_Process_stages_interview_status_id", "tbl_process_stages", "id")

                .WithColumn("candidate_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_candidates table defines the id of the candidate")
                 .ForeignKey("FK_tbl_interview_details_tbl_candidates_CandidateId", "tbl_candidates", "id")

                .WithColumn("start_date_time").AsDateTime().NotNullable().WithColumnDescription("Start date for the candidate used for keeping of history of the candidate interview details")
                 .WithColumn("end_date_time").AsDateTime().NotNullable().WithColumnDescription("end date for the candidate used for keeping track of history of the candidate interview details")
                 .WithColumn("status_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_interview_round_statuses table defines the the round status")
                 .ForeignKey("FK_tbl_interview_details_tblInteviewRoundStatuses_StatusId", "tbl_interview_round_statuses", "id")
                 .WithColumn("reason").AsString(150).Nullable().WithColumnDescription("Notes on the Interview Process if needed");

        }
        public override void Down()
        {
            Delete.Table("tbl_logins");
            Delete.Table("tbl_employees");
            Delete.Table("tbl_sources");
            Delete.Table("tbl_locations");
            Delete.Table("tbl_process_statuses");
            Delete.Table("tbl_process_stages");
            Delete.Table("tbl_vacancies");
            Delete.Table("tbl_interview_round_statuses");
            Delete.Table("tbl_owners");
            Delete.Table("tbl_candidates");
            Delete.Table("tbl_preferred_locations");
            Delete.Table("tbl_interview_details");


        }
    }
    /// <summary>
    /// insert default values to the tables
    /// </summary>

    [Migration(20201118170500)]
    public class Inserttblinetviewers : Migration
    {
        public override void Up()
        {
            Create.Table("tbl_interviewers").WithDescription("Table used to store the multiple ineterviewer details")                  //Creation of tbl_preferred_locations
             .WithColumn("id").AsInt64().Identity().PrimaryKey().WithColumnDescription("Primary key")
                .WithColumn("candidate_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_candidates table defines the id of the candidate")
        .ForeignKey("FK_tbl_interviewers_tbl_candidates_CandidateId", "tbl_candidates", "id")
        .WithColumn("employee_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_employees table defines the interviewers")
        .ForeignKey("FK_tbl_interviewers_tbl_employees_employye_id", "tbl_employees", "id")
         .WithColumn("interview_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_interview_details table defines the interview")
        .ForeignKey("FK_tbl_interviewers_tbl_interview_details_id", "tbl_interview_details", "id");
        }

        public override void Down()
        {
            Delete.Table("tbl_interviewers");
        }
    }




    public class Init
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Init));
        internal static IConfiguration _configuration;

        //public Init(IConfiguration config)
        //{
        //    this._configuration = config;
        //}


        public static IServiceProvider CreateServices()
        {

            try
            {
                return new ServiceCollection()
                    // Add common FluentMigrator services
                    .AddFluentMigratorCore()
                    .ConfigureRunner(rb =>
                    {
                        IMigrationRunnerBuilder supp = null;

                        supp = rb
                         // .AsGlobalPreview()
                         // Add SQLite support to FluentMigrator
                         .AddSqlServer();

                        //supp = rb.AddSQLite();

                        // Set the connection string
                        supp.WithGlobalConnectionString(_configuration.GetConnectionString("MyConn"))
                           // Define the assembly containing the migrations
                           .ScanIn(typeof(CreateTables).Assembly).For.Migrations();
                    }
                    )
                    // Enable logging to console in the FluentMigrator way
                    .AddLogging(lb => lb.AddFluentMigratorConsole())
                    // Build the service provider
                    .BuildServiceProvider(false);

            }
            catch (Exception ex)
            {
                log.Error("[CreateServices]: ", ex);
                return null;
            }
        }

        /// <summary>
        /// Update the database
        /// </summary>
        public static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            log.Info("[UpdateDatabase]:Migrate Start");
            try
            {
                runner.MigrateUp();
                log.Info("[UpdateDatabase]:Migrate End");
            }
            catch (Exception ex)
            {
                log.Error("[UpdateDatabase]: ", ex);
            }

        }
    }
}
