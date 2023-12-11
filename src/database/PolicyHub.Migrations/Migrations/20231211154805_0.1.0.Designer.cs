/********************************************************************************
 * Copyright (c) 2021, 2023 Contributors to the Eclipse Foundation
 *
 * See the NOTICE file(s) distributed with this work for additional
 * information regarding copyright ownership.
 *
 * This program and the accompanying materials are made available under the
 * terms of the Apache License, Version 2.0 which is available at
 * https://www.apache.org/licenses/LICENSE-2.0.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 *
 * SPDX-License-Identifier: Apache-2.0
 ********************************************************************************/

// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Org.Eclipse.TractusX.PolicyHub.Entities;

#nullable disable

namespace Org.Eclipse.TractusX.PolicyHub.Migrations.Migrations
{
    [DbContext(typeof(PolicyHubContext))]
    [Migration("20231211154805_0.1.0")]
    partial class _010
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("policy-hub")
                .UseCollation("en_US.utf8")
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.AttributeKey", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("label");

                    b.HasKey("Id")
                        .HasName("pk_attribute_keys");

                    b.ToTable("attribute_keys", "policy-hub");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "Regex"
                        },
                        new
                        {
                            Id = 2,
                            Label = "Static"
                        },
                        new
                        {
                            Id = 3,
                            Label = "DynamicValue"
                        },
                        new
                        {
                            Id = 4,
                            Label = "Brands"
                        },
                        new
                        {
                            Id = 5,
                            Label = "Version"
                        });
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.Policy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int?>("AttributeKeyId")
                        .HasColumnType("integer")
                        .HasColumnName("attribute_key_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<int>("KindId")
                        .HasColumnType("integer")
                        .HasColumnName("kind_id");

                    b.Property<string>("LeftOperandValue")
                        .HasColumnType("text")
                        .HasColumnName("left_operand_value");

                    b.Property<string>("TechnicalKey")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("technical_key");

                    b.HasKey("Id")
                        .HasName("pk_policies");

                    b.HasIndex("AttributeKeyId")
                        .HasDatabaseName("ix_policies_attribute_key_id");

                    b.HasIndex("KindId")
                        .HasDatabaseName("ix_policies_kind_id");

                    b.ToTable("policies", "policy-hub");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyAssignedTypes", b =>
                {
                    b.Property<Guid>("PolicyId")
                        .HasColumnType("uuid")
                        .HasColumnName("policy_id");

                    b.Property<int>("PolicyTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("policy_type_id");

                    b.HasKey("PolicyId", "PolicyTypeId")
                        .HasName("pk_policy_assigned_types");

                    b.HasIndex("PolicyTypeId")
                        .HasDatabaseName("ix_policy_assigned_types_policy_type_id");

                    b.ToTable("policy_assigned_types", "policy-hub");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyAssignedUseCases", b =>
                {
                    b.Property<Guid>("PolicyId")
                        .HasColumnType("uuid")
                        .HasColumnName("policy_id");

                    b.Property<int>("UseCaseId")
                        .HasColumnType("integer")
                        .HasColumnName("use_case_id");

                    b.HasKey("PolicyId", "UseCaseId")
                        .HasName("pk_policy_assigned_use_cases");

                    b.HasIndex("UseCaseId")
                        .HasDatabaseName("ix_policy_assigned_use_cases_use_case_id");

                    b.ToTable("policy_assigned_use_cases", "policy-hub");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyAttribute", b =>
                {
                    b.Property<Guid>("PolicyId")
                        .HasColumnType("uuid")
                        .HasColumnName("policy_id");

                    b.Property<int>("Key")
                        .HasColumnType("integer")
                        .HasColumnName("key");

                    b.Property<string>("AttributeValue")
                        .HasColumnType("text")
                        .HasColumnName("attribute_value");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.HasKey("PolicyId", "Key", "AttributeValue")
                        .HasName("pk_policy_attributes");

                    b.HasIndex("Key")
                        .HasDatabaseName("ix_policy_attributes_key");

                    b.ToTable("policy_attributes", "policy-hub");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyKind", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("label");

                    b.Property<bool>("TechnicalEnforced")
                        .HasColumnType("boolean")
                        .HasColumnName("technical_enforced");

                    b.HasKey("Id")
                        .HasName("pk_policy_kinds");

                    b.ToTable("policy_kinds", "policy-hub");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "BusinessPartnerNumber",
                            TechnicalEnforced = true
                        },
                        new
                        {
                            Id = 2,
                            Label = "Membership",
                            TechnicalEnforced = true
                        },
                        new
                        {
                            Id = 3,
                            Label = "Framework",
                            TechnicalEnforced = true
                        },
                        new
                        {
                            Id = 4,
                            Label = "Purpose",
                            TechnicalEnforced = false
                        },
                        new
                        {
                            Id = 5,
                            Label = "Dismantler",
                            TechnicalEnforced = true
                        });
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyKindConfiguration", b =>
                {
                    b.Property<int>("PolicyKindId")
                        .HasColumnType("integer")
                        .HasColumnName("policy_kind_id");

                    b.Property<string>("RightOperandValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("right_operand_value");

                    b.HasKey("PolicyKindId")
                        .HasName("pk_policy_kind_configurations");

                    b.ToTable("policy_kind_configurations", "policy-hub");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("label");

                    b.HasKey("Id")
                        .HasName("pk_policy_types");

                    b.ToTable("policy_types", "policy-hub");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Label = "Access"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Label = "Usage"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Label = "Purpose"
                        });
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.UseCase", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_active");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("label");

                    b.HasKey("Id")
                        .HasName("pk_use_cases");

                    b.ToTable("use_cases", "policy-hub");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Label = "Traceability"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Label = "Quality"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Label = "PCF"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Label = "Behavioraltwin"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            Label = "Sustainability"
                        });
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.Policy", b =>
                {
                    b.HasOne("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.AttributeKey", "AttributeKey")
                        .WithMany("Policies")
                        .HasForeignKey("AttributeKeyId")
                        .HasConstraintName("fk_policies_attribute_keys_attribute_key_id");

                    b.HasOne("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyKind", "PolicyKind")
                        .WithMany("Policies")
                        .HasForeignKey("KindId")
                        .IsRequired()
                        .HasConstraintName("fk_policies_policy_kinds_policy_kind_id");

                    b.Navigation("AttributeKey");

                    b.Navigation("PolicyKind");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyAssignedTypes", b =>
                {
                    b.HasOne("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyId")
                        .IsRequired()
                        .HasConstraintName("fk_policy_assigned_types_policies_policy_id");

                    b.HasOne("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyType", "PolicyType")
                        .WithMany()
                        .HasForeignKey("PolicyTypeId")
                        .IsRequired()
                        .HasConstraintName("fk_policy_assigned_types_policy_types_policy_type_id");

                    b.Navigation("Policy");

                    b.Navigation("PolicyType");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyAssignedUseCases", b =>
                {
                    b.HasOne("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyId")
                        .IsRequired()
                        .HasConstraintName("fk_policy_assigned_use_cases_policies_policy_id");

                    b.HasOne("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.UseCase", "UseCase")
                        .WithMany()
                        .HasForeignKey("UseCaseId")
                        .IsRequired()
                        .HasConstraintName("fk_policy_assigned_use_cases_use_cases_use_case_id");

                    b.Navigation("Policy");

                    b.Navigation("UseCase");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyAttribute", b =>
                {
                    b.HasOne("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.AttributeKey", "AttributeKey")
                        .WithMany("PolicyAttributes")
                        .HasForeignKey("Key")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_policy_attributes_attribute_keys_attribute_key_id");

                    b.HasOne("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.Policy", "Policy")
                        .WithMany("Attributes")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_policy_attributes_policies_policy_id");

                    b.Navigation("AttributeKey");

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyKindConfiguration", b =>
                {
                    b.HasOne("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyKind", "PolicyKind")
                        .WithOne("Configuration")
                        .HasForeignKey("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyKindConfiguration", "PolicyKindId")
                        .IsRequired()
                        .HasConstraintName("fk_policy_kind_configurations_policy_kinds_policy_kind_id");

                    b.Navigation("PolicyKind");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.AttributeKey", b =>
                {
                    b.Navigation("Policies");

                    b.Navigation("PolicyAttributes");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.Policy", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("Org.Eclipse.TractusX.PolicyHub.Entities.Entities.PolicyKind", b =>
                {
                    b.Navigation("Configuration");

                    b.Navigation("Policies");
                });
#pragma warning restore 612, 618
        }
    }
}
