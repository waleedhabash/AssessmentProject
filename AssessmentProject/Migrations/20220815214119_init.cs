using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssessmentProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assessment_answers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    assessment_id = table.Column<long>(type: "bigint", maxLength: 20, nullable: false),
                    question_id = table.Column<long>(type: "bigint", maxLength: 20, nullable: false),
                    answer = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    user_id = table.Column<long>(type: "bigint", maxLength: 20, nullable: false),
                    score = table.Column<int>(type: "int", maxLength: 4, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_answers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "assessment_questions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    question = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    category_id = table.Column<long>(type: "bigint", maxLength: 20, nullable: true),
                    level = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    order = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    type = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_questions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "assessments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    titel = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    short_description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    create_by = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    update_by = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    durition = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    category_id = table.Column<long>(type: "bigint", maxLength: 20, nullable: true),
                    thumbnail = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    published = table.Column<int>(type: "int", maxLength: 1, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "assessment_match",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _answer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "NEWID()"),
                    _question_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "NEWID()"),
                    option = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    answer = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    order = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_match", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_match_assessment_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessment_options",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "NEWID()"),
                    option = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    correct = table.Column<int>(type: "int", maxLength: 1, nullable: true),
                    order = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_options", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_options_assessment_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessment_text",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    answer = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    order = table.Column<int>(type: "int", maxLength: 1, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_text", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_text_assessment_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessment_true_false",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    is_true = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_true_false", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_true_false_assessment_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessment_enrols",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    assessment_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<long>(type: "bigint", maxLength: 20, nullable: false),
                    result = table.Column<int>(type: "int", maxLength: 11, nullable: true),
                    score = table.Column<int>(type: "int", maxLength: 4, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_enrols", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_enrols_assessments_assessment_id",
                        column: x => x.assessment_id,
                        principalTable: "assessments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessment_questions_relation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    assessment_id = table.Column<int>(type: "int", nullable: false),
                    question_id = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "Getdate()"),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessment_questions_relation", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessment_questions_relation_assessment_questions_question_id",
                        column: x => x.question_id,
                        principalTable: "assessment_questions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_assessment_questions_relation_assessments_assessment_id",
                        column: x => x.assessment_id,
                        principalTable: "assessments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assessment_enrols_assessment_id",
                table: "assessment_enrols",
                column: "assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_match_question_id",
                table: "assessment_match",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_options_question_id",
                table: "assessment_options",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_questions_relation_assessment_id",
                table: "assessment_questions_relation",
                column: "assessment_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_questions_relation_question_id",
                table: "assessment_questions_relation",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessment_text_question_id",
                table: "assessment_text",
                column: "question_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_assessment_true_false_question_id",
                table: "assessment_true_false",
                column: "question_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assessment_answers");

            migrationBuilder.DropTable(
                name: "assessment_enrols");

            migrationBuilder.DropTable(
                name: "assessment_match");

            migrationBuilder.DropTable(
                name: "assessment_options");

            migrationBuilder.DropTable(
                name: "assessment_questions_relation");

            migrationBuilder.DropTable(
                name: "assessment_text");

            migrationBuilder.DropTable(
                name: "assessment_true_false");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "assessments");

            migrationBuilder.DropTable(
                name: "assessment_questions");
        }
    }
}
